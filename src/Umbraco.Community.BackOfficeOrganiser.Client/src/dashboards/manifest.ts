import {ManifestDashboard} from "@umbraco-cms/backoffice/dashboard";

const dashboards: Array<ManifestDashboard> = [
	{
		type: 'dashboard',
		name: 'timedashboard',
		alias: 'umbraco.community.backofficeorganiser',
		elementName: 'timedashboard-dashboard',
		js: () => import("./organiser.dashboard.ts"),
		weight: -10,
		meta: {
			label: '#boo_dashboardLabel',
			pathname: 'backoffice-organiser'
		},
		conditions: [
			{
				alias: 'Umb.Condition.SectionAlias',
				// @ts-ignore
				match: 'Umb.Section.Settings'
			}
		]
	}
]

export const manifests = [...dashboards];