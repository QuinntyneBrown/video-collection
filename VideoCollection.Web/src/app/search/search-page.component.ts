import { Component, ChangeDetectionStrategy, Input, OnInit } from "@angular/core";

@Component({
    template: require("./search-page.component.html"),
    styles: [require("./search-page.component.scss")],
    selector: "search-page",
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class SearchPageComponent implements OnInit { 
    ngOnInit() {

    }
}
