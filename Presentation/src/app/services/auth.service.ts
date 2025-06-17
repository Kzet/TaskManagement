import { Inject, Injectable } from "@angular/core";
import { BehaviorSubject, Observable, map, finalize, filter, take, switchMap, tap, catchError, throwError, of } from "rxjs";
import { Router } from "@angular/router";
import { HttpClient } from '@angular/common/http';
import { User } from "../models/user/user.model";
import { AuthRequest } from "../models/user/authRequest.model";
import { RefreshToken } from "../models/user/refreshToken.model";
import { NzMessageService } from "ng-zorro-antd/message";

@Injectable({
  providedIn: 'root',
})

export class AuthService {
  private userSubject!: BehaviorSubject<User | null>;
  public user!: Observable<User | null>;
  public isRefreshing = false;

  constructor(
    private router: Router,
    private http: HttpClient,
    private notify: NzMessageService,
    @Inject('API_URL') private apiUrl: string) {
    var localUser = localStorage.getItem('user');
    this.userSubject = new BehaviorSubject<User | null>(
      localUser !== null ? JSON.parse(localUser) : null
    );
    this.user = this.userSubject.asObservable();
  }

  get loggedIn(): boolean {
    return this.userSubject.value !== null;
  }

  public get GetToken(): string {
    if (this.userSubject.value) return this.userSubject.value.token;
    else return '';
  }

  public get GetRefreshToken(): string {
    if (this.userSubject.value) return this.userSubject.value.refreshToken;
    else return '';
  }

  public get userValue(): User | null {
    return this.userSubject.value;
  }

  public isTokenExpired(token: string): boolean {
    const decodedPayload = decodeURIComponent(
      atob(token.split('.')[1].replace(/-/g, "+").replace(/_/g, "/"))
        .split("")
        .map(function (c) {
          return "%" + ("00" + c.charCodeAt(0).toString(16)).slice(-2);
        })
        .join("")
    );
    const expiry = Number((JSON.parse(decodedPayload))["exp"]);
    return Math.floor(Date.now() / 1000) >= expiry;
  }

  refreshToken(email: string, token: string, refreshToken: string): Observable<RefreshToken> {
    let curUser = this.userValue;
    if (curUser && this.GetRefreshToken) {
      if (this.isTokenExpired(this.GetRefreshToken)) {
        this.logout();
        this.notify.create("error", "Превышено время бездействия");
        return of();
      } else {
        curUser.refreshToken = null;
        this.isRefreshing = true;
        this.userSubject.next(curUser);
        return this.http
          .post<RefreshToken>(this.apiUrl + '/auth/refreshToken', { email, token, refreshToken })
          .pipe(
            map((refresh) => {
              curUser.token = refresh.token;
              curUser.refreshToken = refresh.refreshToken;
              this.isRefreshing = false;
              this.userSubject.next(curUser);
              localStorage.setItem('user', JSON.stringify(curUser));
              return curUser;
            }), catchError(error => {
              this.isRefreshing = false;
              this.logout();
              return throwError(error);
            })
          );
      }
    } else {
      this.logout();
      return throwError({
        message: 'Ошибка обновления токена: учетные данные отсутствуют'
      })
    }


  }

  pipeToRefreshToken(): Observable<User> {
    return this.userSubject.pipe(
      filter(user => user.refreshToken != null),
      take(1)
    )
  }

  login(login: AuthRequest) {
    return this.http
      .post<User>(this.apiUrl + '/auth/authenticate', login)
      .pipe(
        map((user) => {
          localStorage.setItem('user', JSON.stringify(user));
          this.userSubject.next(user);
          return user;
        })
      );
  }

  logout() {
    localStorage.removeItem('user');
    this.userSubject.next(null);

    this.router.navigate(['/login']);
  }

  register(user: User
  ) {
    return this.http.post(this.apiUrl + '/auth/register',
      user);
  }

  deleteUser(userId: string) {
    return this.http
      .delete(this.apiUrl + '/auth/deleteUser', {
        params: {
          userId: userId
        }
      });
  }
}
