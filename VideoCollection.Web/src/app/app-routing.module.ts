import { Routes, RouterModule } from '@angular/router';
import { LandingPageComponent } from "./landing";
import { LoginPageComponent } from "./login";
import { AdminPageComponent } from "./admin";
import { AboutPageComponent } from "./about";
import { VideoPageComponent } from "./video";

export const routes: Routes = [
    {
        path: '',
        component: LandingPageComponent,
    },
    {
        path: 'login',
        component: LoginPageComponent,
    },
    {
        path: 'admin',
        component: AdminPageComponent,
    },
    {
        path: 'about',
        component: AboutPageComponent
    },
    {
        path: 'video/:slug',
        component: VideoPageComponent
    }
];

export const RoutingModule = RouterModule.forRoot([
    ...routes
]);

export const routedComponents = [
    AdminPageComponent,
    AboutPageComponent,
    LandingPageComponent,
    LoginPageComponent,
    VideoPageComponent
];