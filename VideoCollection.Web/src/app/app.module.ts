import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserModule  } from '@angular/platform-browser';
import { RouterModule  } from '@angular/router';
import { HttpModule } from '@angular/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import "./rxjs-extensions";
import { AppComponent } from './app.component';
import { AppHeaderComponent } from "./app-header.component";
import { LoginRedirectService, CurrentUserService } from "./login";
import { SharedModule } from "./shared";
import { RoutingModule, routedComponents } from "./app-routing.module";
import { UtilitiesModule } from "./utilities";
import { LoginModule } from "./login";
import { VideoModule } from "./video";

const declarables = [
    AppComponent,
    AppHeaderComponent,
    ...routedComponents
];


@NgModule({
    imports: [
        UtilitiesModule,
        SharedModule,
        RoutingModule,
        BrowserModule,
        HttpModule,
        CommonModule,
        LoginModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule,
        VideoModule   
    ],
    declarations: [declarables],
    exports: [declarables],
    bootstrap: [AppComponent]
})
export class AppModule { }

