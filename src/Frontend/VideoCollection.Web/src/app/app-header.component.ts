import { Component, ChangeDetectionStrategy, Input, OnInit, ViewEncapsulation } from "@angular/core";

@Component({
    template: require("./app-header.component.html"),
    styles: [require("./app-header.component.scss")],
    selector: "app-header",
    encapsulation: ViewEncapsulation.None
})
export class AppHeaderComponent { }
