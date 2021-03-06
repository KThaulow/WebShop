import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './components/app-component/app.component';

import { MatButtonModule, MatCheckboxModule } from '@angular/material';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSidenavModule } from '@angular/material/sidenav';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { LoginComponent } from './layout/identity/login/login.component';
import { AppConfig } from './config/config';
import { AuthGuard } from './helpers/authguard';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RegisterComponent } from './layout/identity/register/register.component';
import { JwtInterceptor } from './helpers/jwt.interceptor';
import { fakeBackendProvider } from './helpers/fake-backend.interceptor';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { UserService } from './services/user.service';
import { HomeComponent } from './layout/main/home/home.component';
import { AlertComponent } from './components/alert/alert.component';
import { AccountComponent } from './layout/account/account.component';
import { FooterComponent } from './layout/footer/footer.component';
import { HeaderComponent } from './layout/header/header.component';
import { HomeBuyComponent } from './layout/main/home-buy/home-buy.component';
import { ImagegridComponent } from './layout/main/imagegrid/imagegrid.component';
import { ImageCarouselComponent } from './layout/main/image-carousel/image-carousel.component';
import { AuthenticationService } from './services/authentication.service';
import { FavoriteComponent } from './components/favorite/favorite.component';
import { CustomTitleCasePipe } from './pipes/customtitlecase.pipe';
import { LikeComponent } from './components/like/like.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    HomeComponent,
    AlertComponent,
    AccountComponent,
    FooterComponent,
    HeaderComponent,
    HomeBuyComponent,
    ImagegridComponent,
    ImageCarouselComponent,
    FavoriteComponent,
    CustomTitleCasePipe,
    LikeComponent
  ],
  imports: [
    BrowserModule,
    MatButtonModule,
    MatCheckboxModule,
    MatInputModule,
    MatFormFieldModule,
    MatSidenavModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    NgbModule,
    FormsModule
  ],
  providers: [
    AppConfig,
    AuthGuard,
    UserService,
    AuthenticationService,
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },

    // provider used to create fake backend
    fakeBackendProvider
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
