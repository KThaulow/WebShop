import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { AppConfig } from '../config/config';
import { User } from '../models/user';

@Injectable({ providedIn: 'root' })
export class AuthenticationService {
    private currentUserSubject: BehaviorSubject<User>;
    private pathAPI = this.config.setting['PathAPI'];
    public currentUser: Observable<User>;

    constructor(private http: HttpClient, private config: AppConfig) {
        this.currentUserSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('currentUser')));
        this.currentUser = this.currentUserSubject.asObservable();
    }

    public get currentUserValue(): User {
        return this.currentUserSubject.value;
    }

    login(username, password): Observable<User> {
        return this.http.post<any>(`${this.pathAPI}/users/authenticate`, { username, password })
            .pipe(map(user => {
                // store user details and jwt token in local storage to keep user logged in between page refreshes
                localStorage.setItem('currentUser', JSON.stringify(user));
                this.currentUserSubject.next(user);
                return user;
            }));
    }

    logout() {
        // remove user from local storage and set current user to null
        localStorage.removeItem('currentUser');
        this.currentUserSubject.next(null);
    }
}