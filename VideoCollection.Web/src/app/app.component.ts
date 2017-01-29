import { Component, ChangeDetectionStrategy, Input, OnInit, ViewEncapsulation } from "@angular/core";
import { Router } from "@angular/router";
 
@Component({
    template: require("./app.component.html"),
    styles: [require("./app.component.scss")],
    selector: "app",
    changeDetection: ChangeDetectionStrategy.OnPush,
    encapsulation: ViewEncapsulation.None
})
export class AppComponent {
    constructor(
        private _router: Router
    ) { }
}
