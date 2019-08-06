// import { async, ComponentFixture, TestBed } from '@angular/core/testing';

// import { AccountComponent } from './account.component';
// import { HttpClientModule, HttpClient } from '@angular/common/http';
// import { User } from 'src/app/models/user';
// import { Observable, BehaviorSubject, of } from 'rxjs';
// import { IAuthenticationService } from 'src/app/services/iauthentication.service';
// import { AppConfig } from 'src/app/config/config';

// describe('AccountComponent', () => {
//   let component: AccountComponent;
//   let fixture: ComponentFixture<AccountComponent>;

//   beforeEach(async(() => {
//     TestBed.configureTestingModule({
//       declarations: [AccountComponent],
//       imports: [HttpClientModule]
//     })
//       .compileComponents();
//   }));

//   beforeEach(() => {
//     fixture = TestBed.createComponent(AccountComponent);
//     var service = new AuthenticationServiceMock(null, null);
//     component = new AccountComponent(service);
//     fixture.detectChanges();
//   });

//   it('should create', () => {
//     expect(component).toBeTruthy();
//   });
// });

// const USER_OBJECT: User = new User();
// class AuthenticationServiceMock implements IAuthenticationService {

//   private currentUserSubject: BehaviorSubject<User>;
//   private pathAPI = "";
//   public currentUser: Observable<User>;

//   constructor(private http: HttpClient, private config: AppConfig) {
//     this.currentUser = new Observable<User>();
//   }

//   login(username, password): Observable<User> {
//     return of(USER_OBJECT);
//   }

//   get currentUserValue(): User {
//     return USER_OBJECT;
//   }

//   logout() {
//   }
// }