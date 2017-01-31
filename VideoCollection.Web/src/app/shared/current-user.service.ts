﻿import { Injectable } from "@angular/core";
import { Storage } from "../utilities";

@Injectable()
export class CurrentUserService {
    constructor(
        private _storage: Storage
    ) {  }

    public get token() { return this._storage.get({ name: "accessToken" }); }

    public get isLoggedIn() { return this.token != null && this.token != "null"; }

}