import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserModule  } from '@angular/platform-browser';
import { RouterModule  } from '@angular/router';
import { HttpModule } from '@angular/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
//import { BlogModule } from "./blog";
import { DigitalAssetModule } from "./digital-assets";
//import { VideoModule } from "./videos";
import { SharedModule } from "./shared";
import { CoreModule } from "./core";
import { UtilitiesModule } from "./utilities";

//import { UserModule } from "./users";

import "./rxjs-extensions";

import { AppComponent } from './app.component';
import { AppHeaderComponent } from "./app-header.component";

import {
    RoutingModule,
    routedComponents
} from "./app-routing.module";

const declarables = [
    AppComponent,
    AppHeaderComponent,
    ...routedComponents
];

const providers = [

];

@NgModule({
    imports: [
        RoutingModule,
        BrowserModule,
        HttpModule,
        CommonModule,
        FormsModule,
        RouterModule,
        ReactiveFormsModule,

        CoreModule,
        UtilitiesModule,
        //BlogModule,
        //VideoModule,
        SharedModule,
        DigitalAssetModule
        //UserModule
    ],
    providers: providers,
    declarations: [declarables],
    exports: [declarables],
    bootstrap: [AppComponent]
})
export class AppModule { }

