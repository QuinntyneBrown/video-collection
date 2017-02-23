import { Injectable } from "@angular/core";

@Injectable()
export class InMemoryStorage {
    constructor() {
        this.put = this.put.bind(this);
        this.get = this.get.bind(this);
    }

    public put(options: any) {

    }

    public get(options:any) {

    }
}