export class ConsumerSystemsInModel {
    public name: string;
    public description: string;
    public consumerProfileId: number;
    public staticIP: string;

    constructor(init?: Partial<ConsumerSystemsInModel>) {
        if(init){
            this.name = init.name;
            this.staticIP = init.staticIP;
            this.description = init.description;
            this.consumerProfileId = init.consumerProfileId;
        }
    }
}