import { Component, ChangeDetectionStrategy, Input, OnInit } from "@angular/core";

@Component({
    template: require("./about-page.component.html"),
    styles: [require("./about-page.component.scss")],
    selector: "about-page",
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class AboutPageComponent implements OnInit { 
    ngOnInit() {

    }
}
