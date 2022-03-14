import { IgxFilteringOperand } from 'igniteui-angular';
import { ERoleTypes } from 'src/app/admin/enums/role-type.enum';

export class IgxRoleEnumFilteringOperand extends IgxFilteringOperand {
    protected constructor() {
        super();
        this.operations = [{
            name: 'Нормална',
            isUnary: true,
            iconName: 'filter_alt',
            logic: (target: number) => {
                return target === ERoleTypes.BASIC;
            }
        },{
            name: 'Публична',
            isUnary: true,
            iconName: 'filter_alt',
            logic: (target: number) => {
                return target === ERoleTypes.PUBLIC;
            }
        },
        {
            name: 'Администратор',
            isUnary: true,
            iconName: 'filter_alt',
            logic: (target: number) => {
                return target === ERoleTypes.ADMIN;
            }
        }
        ,{
            name: 'empty',
            isUnary: true,
            iconName: 'is-empty',
            logic: (target: string) => {
                return target === null || target === undefined || target.length === 0;
            }
        },
         {
            name: 'notEmpty',
            isUnary: true,
            iconName: 'not-empty',
            logic: (target: string) => {
                return target !== null && target !== undefined && target.length > 0;
            }
        }].concat(this.operations);
    }

    /**
     * Applies case sensitivity on strings if provided
     *
     * @memberof IgxStringFilteringOperand
     */
    public static applyIgnoreCase(a: string, ignoreCase: boolean): string {
        a = a || '';
        // bulletproof
        return ignoreCase ? ('' + a).toLowerCase() : a;
    }
}