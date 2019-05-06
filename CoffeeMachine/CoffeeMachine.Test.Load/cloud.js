import { check, group, sleep } from "k6";
import http from "k6/http";
const baseUrl = "https://loadtestingazure.azurewebsites.net/";


export let options = {
    stages: [
        {duration: "60s", target: 100},
        {duration: "40s", target: 150},
        {duration: "60s", target: 20},
    ],
    thresholds: {
        "http_req_duration": ["p(90)<400"]
    }
};

export default function() {
    group("machine-page", function() {
        let res = http.get(baseUrl + 'machine');
        check(res, {
            "is status 200": (r) => r.status === 200
        });
        sleep(5);
    });

    group("drink-api", function() {
        let res = http.get(baseUrl + 'drink');
        check(res, {
            "is status 200": (r) => r.status === 200
        });
        sleep(5);
    });
}