export class VacationRequest {
    days!: number;

    constructor(requestedDays: number) {
        this.days = requestedDays;
    }
}