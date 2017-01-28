import { Component, ChangeDetectionStrategy, Input, OnInit } from "@angular/core";

@Component({
    template: require("./admin-page.component.html"),
    styles: [require("./admin-page.component.scss")],
    selector: "admin-page",
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class AdminPageComponent implements OnInit { 
    ngOnInit() {

    }
}
