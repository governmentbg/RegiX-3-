import { IgxFilteringOperand, IgxStringFilteringOperand } from 'igniteui-angular';

/**
 * Provides filtering operations for DisplayValues
 *
 * @export
 */
export class DisplayValueFilteringOperand extends IgxFilteringOperand {
    protected constructor() {
        super();
        this.operations = [{
            name: 'contains',
            isUnary: false,
            iconName: 'contains',
            logic: (target: {displayName: string;}, searchVal: string, ignoreCase?: boolean) => {
                const search = IgxStringFilteringOperand.applyIgnoreCase(searchVal, ignoreCase);
                const targetDisplayValue = IgxStringFilteringOperand.applyIgnoreCase(
                  (target !== null && target !== undefined) ? target.displayName : '', ignoreCase);
                return targetDisplayValue.indexOf(search) !== -1;
            }
        }, {
            name: 'doesNotContain',
            isUnary: false,
            iconName: 'does_not_contain',
            logic: (target: {displayName: string;}, searchVal: string, ignoreCase?: boolean) => {
                const search = IgxStringFilteringOperand.applyIgnoreCase(searchVal, ignoreCase);
                const targetDisplayValue = IgxStringFilteringOperand.applyIgnoreCase(
                  (target !== null && target !== undefined) ? target.displayName : '', ignoreCase);
                return targetDisplayValue.indexOf(search) === -1;
            }
        }, {
            name: 'startsWith',
            isUnary: false,
            iconName: 'starts_with',
            logic: (target: {displayName: string;}, searchVal: string, ignoreCase?: boolean) => {
                const search = IgxStringFilteringOperand.applyIgnoreCase(searchVal, ignoreCase);
                const targetDisplayValue = IgxStringFilteringOperand.applyIgnoreCase(
                  (target !== null && target !== undefined) ? target.displayName : '', ignoreCase);
                return targetDisplayValue.startsWith(search);
            }
        }, {
            name: 'endsWith',
            isUnary: false,
            iconName: 'ends_with',
            logic: (target: {displayName: string;}, searchVal: string, ignoreCase?: boolean) => {
                const search = IgxStringFilteringOperand.applyIgnoreCase(searchVal, ignoreCase);
                const targetDisplayValue = IgxStringFilteringOperand.applyIgnoreCase(
                  (target !== null && target !== undefined) ? target.displayName : '', ignoreCase);
                return targetDisplayValue.endsWith(search);
            }
        }, {
            name: 'equals',
            isUnary: false,
            iconName: 'equals',
            logic: (target: {displayName: string;}, searchVal: string, ignoreCase?: boolean) => {
                const search = IgxStringFilteringOperand.applyIgnoreCase(searchVal, ignoreCase);
                const targetDisplayValue = IgxStringFilteringOperand.applyIgnoreCase(
                  (target !== null && target !== undefined) ? target.displayName : '', ignoreCase);
                return targetDisplayValue === search;
            }
        }, {
            name: 'doesNotEqual',
            isUnary: false,
            iconName: 'not_equal',
            logic: (target: {displayName: string;}, searchVal: string, ignoreCase?: boolean) => {
                const search = IgxStringFilteringOperand.applyIgnoreCase(searchVal, ignoreCase);
                const targetDisplayValue = IgxStringFilteringOperand.applyIgnoreCase(
                  (target !== null && target !== undefined) ? target.displayName : '', ignoreCase);
                return targetDisplayValue !== search;
            }
        }, {
            name: 'empty',
            isUnary: true,
            iconName: 'empty',
            logic: (target: {displayName: string;}) => {
                return target === null ||
                target === undefined ||
                target.displayName === null ||
                target.displayName === undefined ||
                target.displayName.length === 0;
            }
        }, {
            name: 'notEmpty',
            isUnary: true,
            iconName: 'not_empty',
            logic: (target: {displayName: string;}) => {
                return target !== null &&
                target !== undefined &&
                target.displayName !== null &&
                target.displayName !== undefined &&
                target.displayName.length > 0;
            }
        }].concat(this.operations);
    }
  }