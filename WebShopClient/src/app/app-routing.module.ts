import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './helpers/authguard';
import { LoginComponent } from './layout/identity/login/login.component';
import { RegisterComponent } from './layout/identity/register/register.component';
import { AccountComponent } from './layout/account/account.component';
import { HomeComponent } from './layout/main/home/home.component';
import { HomeBuyComponent } from './layout/main/home-buy/home-buy.component'
import { HeaderComponent } from './layout/header/header.component';
import { FooterComponent } from './layout/footer/footer.component';
import { ImagegridComponent } from './layout/main/imagegrid/imagegrid.component';
import { ImageCarouselComponent } from './layout/main/image-carousel/image-carousel.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'account', component: AccountComponent, canActivate: [AuthGuard] },

  // otherwise redirect to home
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
