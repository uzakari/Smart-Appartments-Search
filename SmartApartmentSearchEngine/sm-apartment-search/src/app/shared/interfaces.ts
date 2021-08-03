export interface MarketScope {
        state: string;
        cities: string[];
    
}


export interface SearchResultContents {
    name: string;
    market: string;
    isManagement: boolean;
}

export interface SearchResult {
    data: SearchResultContents[];
    success: boolean;
    message: string;
    validationErrors: string[];
}