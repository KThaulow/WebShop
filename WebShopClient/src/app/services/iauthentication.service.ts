import { Observable } from "rxjs";
import { User } from '../models/user';

export interface IAuthenticationService {
    currentUser: Observable<User>;
    currentUserValue(): User;
    login(username, password): Observable<User>;
    logout();
}