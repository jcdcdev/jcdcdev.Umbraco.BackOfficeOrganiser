import {UmbControllerHost} from "@umbraco-cms/backoffice/controller-api";
import {UmbDataSourceResponse} from "@umbraco-cms/backoffice/repository";
import {tryExecuteAndNotify} from "@umbraco-cms/backoffice/resources";
import {
	getUmbracoBackOfficeOrganiserApiV1Info, type GetUmbracoBackOfficeOrganiserApiV1InfoResponse,
	postUmbracoBackOfficeOrganiserApiV1Organise,
	PostUmbracoBackOfficeOrganiserApiV1OrganiseData,
	PostUmbracoBackOfficeOrganiserApiV1OrganiseResponse
} from "../api";

export class BackofficeOrganiserDataSource implements IBackofficeOrganiserDataSource {

	#host: UmbControllerHost;

	constructor(host: UmbControllerHost) {
		this.#host = host;
	}

	async organise(data: PostUmbracoBackOfficeOrganiserApiV1OrganiseData = {}): Promise<UmbDataSourceResponse<PostUmbracoBackOfficeOrganiserApiV1OrganiseResponse>> {
		return await tryExecuteAndNotify(this.#host, postUmbracoBackOfficeOrganiserApiV1Organise(data))
	}

	async getInfo(): Promise<UmbDataSourceResponse<GetUmbracoBackOfficeOrganiserApiV1InfoResponse>> {
		return await tryExecuteAndNotify(this.#host, getUmbracoBackOfficeOrganiserApiV1Info())
	}
}

export interface IBackofficeOrganiserDataSource {
	organise(data: PostUmbracoBackOfficeOrganiserApiV1OrganiseData): Promise<UmbDataSourceResponse<PostUmbracoBackOfficeOrganiserApiV1OrganiseResponse>>;

	getInfo(): Promise<UmbDataSourceResponse<GetUmbracoBackOfficeOrganiserApiV1InfoResponse>>;
}

