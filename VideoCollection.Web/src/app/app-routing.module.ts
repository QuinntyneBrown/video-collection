import { Routes, RouterModule } from '@angular/router';
import { LandingPageComponent } from "./landing";
import { LoginPageComponent } from "./login";
import {
    AdminPageComponent,
    DigitalAssetUploadPageComponent,
    DigitalAssetEditPageComponent,
    DigitalAssetListPageComponent,

    VideoEditPageComponent,
    VideoListPageComponent
} from "./admin";
import { AboutPageComponent } from "./about";
import { VideoPageComponent } from "./video";
import { AuthGuardService } from "./shared";

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
            { path: 'digital-asset/upload', component: DigitalAssetUploadPageComponent },
            { path: 'digital-asset/list', component: DigitalAssetListPageComponent },
            { path: 'digital-asset/edit/:id', component: DigitalAssetEditPageComponent },

            { path: 'video/create', component:  VideoEditPageComponent},
            { path: 'video/list', component: VideoListPageComponent },
            { path: 'video/edit/:id', component: VideoEditPageComponent}
        ],
        canActivate:[AuthGuardService]
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
    DigitalAssetEditPageComponent,
    DigitalAssetListPageComponent,

    VideoEditPageComponent,
    VideoListPageComponent,

    AboutPageComponent,
    LandingPageComponent,
    LoginPageComponent,
    VideoPageComponent
];