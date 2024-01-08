export class WorkRequest {
    days!: number;

    constructor(requestedDays: number) {
        this.days = requestedDays;
    }
}