﻿import { Injectable } from "@angular/core";

@Injectable()
export class CurrentUserService {
    constructor() { }

    public get isLoggedIn() {
        return true;
    }
}