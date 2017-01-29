import { Routes, RouterModule } from '@angular/router';
import { LandingPageComponent } from "./landing";
import { LoginPageComponent } from "./login";
import { AdminPageComponent, DigitalAssetUploadPageComponent } from "./admin";
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
        children: [
            { path: 'digital-asset/upload', component: DigitalAssetUploadPageComponent }
        ]
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
    DigitalAssetUploadPageComponent,
    AboutPageComponent,
    LandingPageComponent,
    LoginPageComponent,
    VideoPageComponent
];