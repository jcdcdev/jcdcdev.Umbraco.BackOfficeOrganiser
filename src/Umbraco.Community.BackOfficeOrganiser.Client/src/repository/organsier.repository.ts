import {UmbControllerHost} from "@umbraco-cms/backoffice/controller-api";
import {UmbDataSourceResponse} from "@umbraco-cms/backoffice/repository";
import {UmbControllerBase} from "@umbraco-cms/backoffice/class-api";
import {BackofficeOrganiserDataSource, IBackofficeOrganiserDataSource} from "../datasource/organiser.datasource.ts";
import {type GetUmbracoBackOfficeOrganiserApiV1InfoResponse, PostUmbracoBackOfficeOrganiserApiV1OrganiseData, PostUmbracoBackOfficeOrganiserApiV1OrganiseResponse} from "../api";

export class BackofficeOrganiserRepository extends UmbControllerBase {
	#resource: IBackofficeOrganiserDataSource;

	constructor(host: UmbControllerHost) {
		super(host);
		this.#resource = new BackofficeOrganiserDataSource(host);
	}

	organise(data: PostUmbracoBackOfficeOrganiserApiV1OrganiseData = {}): Promise<UmbDataSourceResponse<PostUmbracoBackOfficeOrganiserApiV1OrganiseResponse>> {
		return this.#resource.organise(data);
	}

	getInfo(): Promise<UmbDataSourceResponse<GetUmbracoBackOfficeOrganiserApiV1InfoResponse>> {
		return this.#resource.getInfo();
	}
}

