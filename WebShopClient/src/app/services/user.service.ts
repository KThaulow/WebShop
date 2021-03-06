import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from '../models/user';
import { AppConfig } from '../config/config';

@Injectable()
export class UserService {

    private pathAPI = this.config.setting['PathAPI'];

    constructor(private http: HttpClient, private config: AppConfig) { }

    getAll() {
        return this.http.get<User[]>(`${this.pathAPI}/users`);
    }

    register(user: User) {
        return this.http.put(`${this.pathAPI}/users`, user);
    }

    delete(id: number) {
        return this.http.delete(`${this.pathAPI}/users/${id}`);
    }
} 