export class User {
    username!: string;

    constructor(loginUser: string) {
        this.username = loginUser;
    }
}