# -*- coding: utf-8 -*-

import json
import requests
import csv
import sys


# --------- 参数 -----------
tk = "82336205e2fbc3838263aeb80c78112a"
tk = sys.argv[1]

keyWord = ""
keyWord = sys.argv[2]

mapBound = "114.511091799971,38.1820116282628,114.513468597248,38.1859512547416"
mapBound = sys.argv[3]

queryType = "7"
queryType = sys.argv[4]

outCSV = 'C:\\Users\\dell\\Desktop\\csv.csv'
outCSV = sys.argv[5]

# --------------------------

if queryType == "7":
    keyWord = "1"

# --------------------------

poiJSON = {
    "keyWord": keyWord,
    "level": "20",
    "mapBound": mapBound,
    "queryType": queryType,
    "count": "1",
    "start": "0"     
}
if queryType == "7":
    poiJSON['queryTerminal'] = '10000'

params = {
    "postStr": str(poiJSON),
    "type": "query",
    "tk": tk
}

r = requests.get('http://api.tianditu.gov.cn/search', params=params)
dic = json.loads(r.text)
poiJSON['count'] = dic['count']
params['postStr'] = str(poiJSON)

r = requests.get('http://api.tianditu.gov.cn/search', params=params)
dic = json.loads(r.text)
pois = dic['pois']

with open(outCSV, 'w', newline='', encoding='utf-8') as csvfile:
    fieldnames = ['hotPointID', 'lon', 'lat', 'name', 'ename', 'address', 'phone', 'eaddress']
    writer = csv.DictWriter(csvfile, fieldnames=fieldnames)
    writer.writeheader()
    for poi in pois:
        poi['lon'] = poi['lonlat'].split(' ')[0]
        poi['lat'] = poi['lonlat'].split(' ')[1]
        print("{0}, {1}".format(poi['lon'], poi['lat']))
        del poi['lonlat']
        try:
            del poi['poiType']
            del poi['stationData']
        except:
            pass
        writer.writerow(poi)



