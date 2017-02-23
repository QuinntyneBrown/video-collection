import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserModule  } from '@angular/platform-browser';
import { RouterModule  } from '@angular/router';
import { HttpModule } from '@angular/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import "./rxjs-extensions";
import { AppComponent } from './app.component';
import { AppHeaderComponent } from "./app-header.component";
import { RoutingModule, routedComponents } from "./app-routing.module";
import { UtilitiesModule } from "./utilities";
import { VideoModule } from "./video";
import { SharedModule } from "./shared";

const declarables = [
    AppComponent,
    AppHeaderComponent,
    ...routedComponents
];


@NgModule({
    imports: [
        UtilitiesModule,
        RoutingModule,
        BrowserModule,
        HttpModule,
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule,
        SharedModule,
        VideoModule   
    ],
    declarations: [declarables],
    exports: [declarables],
    bootstrap: [AppComponent]
})
export class AppModule { }

