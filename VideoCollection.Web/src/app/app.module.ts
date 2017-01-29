import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserModule  } from '@angular/platform-browser';
import { RouterModule  } from '@angular/router';
import { HttpModule } from '@angular/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ApiService, Storage, OAuthHelper } from "./shared";

import "./rxjs-extensions";

import { AppComponent } from './app.component';

import { LoginRedirectService, CurrentUserService } from "./login";

import {
    RoutingModule,
    routedComponents
} from "./app-routing.module";

const declarables = [
    AppComponent,
    ...routedComponents
];

const providers = [
    ApiService,
    Storage,
    OAuthHelper,
    LoginRedirectService,
    CurrentUserService
];

@NgModule({
    imports: [
        RoutingModule,
        BrowserModule,
        HttpModule,
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule
    ],
    providers: providers,
    declarations: [declarables],
    exports: [declarables],
    bootstrap: [AppComponent]
})
export class AppModule { }

