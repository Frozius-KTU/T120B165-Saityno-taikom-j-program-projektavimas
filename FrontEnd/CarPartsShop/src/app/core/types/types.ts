export type Views = 'dropdowns' | 'grids' | 'inputs' | 'layout';
export type UtilsComponentName = 'expand' | 'tabstrip' | 'dropdownlist' | 'grid' | 'textbox' | 'numeric-textbox';
export type GridData = { name: string; type: string; default: string; description: string };
export type UtilsComponent = { code: string; inputs: GridData[]; events: GridData[] };
