import { Routes, RouterModule } from '@angular/router';
import { LandingPageComponent } from "./landing";
import { AboutPageComponent } from "./about";
import { VideoPageComponent } from "./video";
import { SearchPageComponent } from "./search";

export const routes: Routes = [
    {
        path: '',
        component: LandingPageComponent,
    },
    {
        path: 'about',
        component: AboutPageComponent
    },
    {
        path: 'search',
        component: SearchPageComponent
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
    AboutPageComponent,
    LandingPageComponent,
    VideoPageComponent,
    SearchPageComponent
];