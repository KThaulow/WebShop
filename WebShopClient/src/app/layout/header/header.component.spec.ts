import { async, ComponentFixture, TestBed, inject } from '@angular/core/testing';

import { HeaderComponent } from './header.component';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { User } from 'src/app/models/user';
import { of, Observable, BehaviorSubject } from 'rxjs';
import { AppConfig } from 'src/app/config/config';
import { IAuthenticationService } from 'src/app/services/iauthentication.service';

describe('HeaderComponent', () => {
  let component: HeaderComponent;
  let service: AuthenticationServiceMock;
  let fixture: ComponentFixture<HeaderComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [HeaderComponent],
      imports: [HttpClientModule],
      providers: [AppConfig]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HeaderComponent);
    // component = fixture.componentInstance;
    service = new AuthenticationServiceMock(null, null);
    component = new HeaderComponent(service);
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});



const USER_OBJECT: User = new User();
class AuthenticationServiceMock implements IAuthenticationService {

  private currentUserSubject: BehaviorSubject<User>;
  private pathAPI = "";
  public currentUser: Observable<User>;

  constructor(private http: HttpClient, private config: AppConfig) {
    this.currentUser = new Observable<User>();
  }

  login(username, password): Observable<User> {
    return of(USER_OBJECT);
  }

  currentUserValue(): User {
    return USER_OBJECT;
  }

  logout() {
  }
}