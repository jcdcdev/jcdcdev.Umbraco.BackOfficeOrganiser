import {OrganiseType} from "./organise-type.ts";

export class OrganiseTypeModel {
	value: OrganiseType;
	label: string;
	selected: boolean;
	constructor(value: number, label: string, selected: boolean) {
		this.value = value;
		this.label = label;
		this.selected = selected;
	}
}