import { Component, ChangeDetectionStrategy, Input, OnInit, ViewEncapsulation } from "@angular/core";

@Component({
    template: require("./admin-page.component.html"),
    styles: [require("./admin-page.component.scss")],
    selector: "admin-page",
    encapsulation: ViewEncapsulation.None
})
export class AdminPageComponent implements OnInit { 
    ngOnInit() {

    }
}
