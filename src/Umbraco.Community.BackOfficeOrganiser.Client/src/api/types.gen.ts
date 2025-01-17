// This file is auto-generated by @hey-api/openapi-ts

export type EventMessageTypeModel = 'Default' | 'Info' | 'Error' | 'Success' | 'Warning';

export type NotificationHeaderModel = {
    message: string;
    category: string;
    type: EventMessageTypeModel;
};

export type OrganiseInfoModel = {
    alias: string;
    name: string;
    description: string;
};

export type OrganiseInfoResponse = {
    dataTypes: Array<(OrganiseInfoModel)>;
    contentTypes: Array<(OrganiseInfoModel)>;
    mediaTypes: Array<(OrganiseInfoModel)>;
    memberTypes: Array<(OrganiseInfoModel)>;
};

export type OrganiseRequest = {
    dataTypes: boolean;
    contentTypes: boolean;
    mediaTypes: boolean;
    memberTypes: boolean;
};

export type OrganiseResponse = {
    readonly error: boolean;
    readonly message: string;
};

export type GetUmbracoBackOfficeOrganiserApiV1InfoResponse = ((OrganiseInfoResponse));

export type PostUmbracoBackOfficeOrganiserApiV1OrganiseData = {
    requestBody?: (OrganiseRequest);
};

export type PostUmbracoBackOfficeOrganiserApiV1OrganiseResponse = ((OrganiseResponse));