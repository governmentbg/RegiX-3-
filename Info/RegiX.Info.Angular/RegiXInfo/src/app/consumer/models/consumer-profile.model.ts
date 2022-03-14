import { ABaseModel } from '@tl/tl-common';
export class ConsumerProfileModel extends ABaseModel{
    public name: string;
    public identifier: string;
    public identifierType: number;
    public documentNumber: string;

    constructor(init?: Partial<ConsumerProfileModel>) {
        super(init);
        if(init){
            this.name = init.name;
            this.identifier = init.identifier;
            this.identifierType = init.identifierType;
            this.documentNumber = init.documentNumber;
        }
    }
}