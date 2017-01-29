import { Component, ChangeDetectionStrategy, Input, OnInit } from "@angular/core";

@Component({
    template: require("./app-header.component.html"),
    styles: [require("./app-header.component.scss")],
    selector: "app-header",
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class AppHeaderComponent implements OnInit { 
    ngOnInit() {

    }
}
