import { Component, ChangeDetectionStrategy, Input, OnInit } from "@angular/core";

@Component({
    template: require("./admin-header.component.html"),
    styles: [require("./admin-header.component.scss")],
    selector: "admin-header",
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class AdminHeaderComponent implements OnInit { 
    ngOnInit() {

    }
}
