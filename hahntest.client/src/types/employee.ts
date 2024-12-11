
/**
 * 
 * @export
 * @interface Employee
 */
export interface Employee {
    /**
     * 
     * @type {string}
     * @memberof Employee
     */
    'id': string ;
    /**
     * 
     * @type {string}
     * @memberof Employee
     */
    'name'?: string | null;
    /**
     * 
     * @type {string}
     * @memberof Employee
     */
    'position'?: string | null;
    /**
     * 
     * @type {number}
     * @memberof Employee
     */
    'salary'?: number;
}