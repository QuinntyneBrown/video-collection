import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserModule  } from '@angular/platform-browser';
import { RouterModule  } from '@angular/router';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { BlogModule } from "./blog";
import { DigitalAssetModule } from "./digital-assets";
import { VideoModule } from "./videos";
import { SharedModule } from "./shared";

import "./rxjs-extensions";

import { AppComponent } from './app.component';

import {
    RoutingModule,
    routedComponents
} from "./app-routing.module";

const declarables = [
    AppComponent,
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

        BlogModule,
        VideoModule,
        SharedModule,
        DigitalAssetModule
    ],
    providers: providers,
    declarations: [declarables],
    exports: [declarables],
    bootstrap: [AppComponent]
})
export class AppModule { }

