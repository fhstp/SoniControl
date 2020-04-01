/*
 * Copyright (c) 2020. Alexis Ringot, Florian Taurer, Matthias Zeppelzauer.
 *
 * This file is part of SoniControl server.
 *
 *     SoniControl server is free software: you can redistribute it and/or modify
 *     it under the terms of the GNU General Public License as published by
 *     the Free Software Foundation, either version 3 of the License, or
 *     (at your option) any later version.
 *
 *     SoniControl server is distributed in the hope that it will be useful,
 *     but WITHOUT ANY WARRANTY; without even the implied warranty of
 *     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *     GNU General Public License for more details.
 *
 *     You should have received a copy of the GNU General Public License
 *     along with SoniControl server.  If not, see <http://www.gnu.org/licenses/>.
 */

const socket = io.connect('SERVER_URL'); //CHANGE BEFORE FIRST START

socket.emit('connectClient');

socket.on('connectClientResult', function (data) {
    socket.emit('requestMarkers');
    setDefaultOfFilter();
});

socket.on('sendMarkerData', function (data) {
    technologies = data.technologyList;
    detections = data.detectionList;
    loadMarkers(data.detectionList, data.amplitudeMax, data.amplitudeMin);
    loadSidepanelEntries(data.detectionList);
    addTechnologiesToSidebar(data.technologyList);
});

socket.on('reloadMarker', function (data) {
    technologies = data.technologyList;
    detections = data.detectionList;
    source.clear();
    markerVectorLayer = null;
    loadMarkers(data.detectionList, data.amplitudeMax, data.amplitudeMin);
    loadSidepanelEntries(data.detectionList);
});

var detections = [];

var technologies = [];

var container = document.getElementById('popup');
var content = document.getElementById('popup-content');
var closer = document.getElementById('popup-closer');

function loadSidepanelEntries(detections){
    deleteAllSidepanelEntries();
    for(i = 0; i<detections.length;i++){
        var entryName = detections[i].detection.technology + "-" + detections[i].detection.timestamp;
        var entryTechnology = detections[i].technology;
        var entryTimestamp = detections[i].detection.timestamp.substring(0,10) + " " + detections[i].detection.timestamp.substring(11,19);
        createSidepanelEntry(entryName, entryTechnology, entryTimestamp);
    }
}

function createSidepanelEntry(detectionName, entryTechnology, entryTimestamp){
    var sidepanel = document.getElementById('sidepanel');
    var sidepanelEntry = document.createElement('div');
    sidepanelEntry.id = detectionName;
    sidepanelEntry.className = 'detectionEntry';

    var sidepanelEntryTech = document.createElement('div');
    sidepanelEntryTech.className = 'detectionEntryTech';
    var techString;
    if(entryTechnology.length>1){
        for (k = 0; k<entryTechnology.length;k++){
            if(k==0){ 
                techString = entryTechnology[k];
            }else{
                techString = techString + ", " + entryTechnology[k];
            }
        }
    }else{
        techString = entryTechnology[0];
    }
    sidepanelEntryTech.innerHTML = techString;
    var sidepanelEntryTime = document.createElement('div');
    sidepanelEntryTime.innerHTML = entryTimestamp;

    sidepanelEntry.appendChild(sidepanelEntryTech);
    sidepanelEntry.appendChild(sidepanelEntryTime);
    sidepanelEntry.onclick = function(){
        centerMarker(detectionName);
    }
    sidepanel.appendChild(sidepanelEntry);
}

function deleteAllSidepanelEntries(){
    const sidepanel = document.getElementById('sidepanel');
    while (sidepanel.firstChild) {
        sidepanel.removeChild(sidepanel.firstChild);
    }
}

function centerMarker(featureID){
    var coordinates = source.getFeatureById(featureID).getGeometry().getCoordinates();
    var lonlat = ol.proj.transform(coordinates, 'EPSG:3857', 'EPSG:4326');

    var feature = source.getFeatureById(featureID);

    var popupText = 
                        '<p>Detected technology: '+feature.getProperties().techName+'</p>'+
                        '<p>Longitude: '+feature.getProperties().lon+ ', Latitude: '+feature.getProperties().lat+'</p>' + 
                        '<p>Detected times: '+feature.getProperties().count+'</p>' +
                        '<p>Latest amplitude: '+feature.getProperties().amplitude+'</p>' + '<p>Last detected: '+feature.getProperties().timestamp+'</p>';

    content.innerHTML = popupText;
    var hdms = ol.coordinate.toStringHDMS(ol.proj.toLonLat(coordinates));
    content.innerHTML = popupText;
    overlay.setPosition(coordinates);

    centerMap(lonlat[0], lonlat[1]);
}

function centerMap(long, lat) {
    map.getView().setCenter(ol.proj.transform([long, lat], 'EPSG:4326', 'EPSG:3857'));
    map.getView().setZoom(15);
}

var overlay = new ol.Overlay({
    element: container,
    autoPan: true,
    autoPanAnimation: {
      duration: 250
    }
});

var distance = 51;

var raster = new ol.layer.Tile({
    source: new ol.source.OSM()
});

var map = new ol.Map({
    layers: [raster],
    target: 'map',
    overlays: [overlay],
    view: new ol.View({
      center: ol.proj.fromLonLat([9.25, 50.1]),
      zoom: 5
    })
});

closer.onclick = function() {closePopup()};

function closePopup() {
    overlay.setPosition(undefined);
    closer.blur();
    return false;
};

let markerVectorLayer;
let source;

function loadMarkers(detections, amplitudeMax, amplitudeMin) {
    var vectorSource = new Array(detections.length);

    for(i=0; i<detections.length; i++) {
        var marker = createMarker(detections[i].detection, detections[i].technologyid, detections[i].technology, detections[i].count, amplitudeMax, amplitudeMin);
        vectorSource[i] = marker;
    }

    source = new ol.source.Vector({
        features: vectorSource
      });

    var clusterSource = new ol.source.Cluster({
        distance: parseInt(distance, 10),
        source: source
    });

    var styleCache = {};
    var clusters = new ol.layer.Vector({
        source: clusterSource,
        updateWhileInteracting: true,
        style: function(feature, resolution) {
            var size = feature.get('features').length;
            if(size===1){
                var src = "../assets/icons/marker_black.png";
                var color = 'rgba(0, 0, 0, 0.70)';
                var stroke = 'rgba(0, 0, 0, 0.90)';
                var textColor = '#FFF';

                var techId = feature.get('features')[0].getProperties().techId;
                var strokeWidth = 2.5;

                switch(techId){
                    case 0:
                        src = "../assets/icons/marker_black.png";
                        color = 'rgba(0, 0, 0, 0.70)';
                        stroke = 'rgba(0, 0, 0, 0.90)';
                        textColor = '#FFF';
                        break;
                    case 1:
                        src = "../assets/icons/marker_green.png";
                        color = 'rgba(214, 188, 40, 0.70)';
                        stroke = 'rgba(214, 188, 40, 0.90)';
                        textColor = '#000';
                        break;
                    case 2:
                        src = "../assets/icons/marker_blue.png";
                        color = 'rgba(0, 0, 255, 0.70)';
                        stroke = 'rgba(0, 0, 255, 0.90)';
                        textColor = '#FFF';
                        break;
                    case 3:
                        src = "../assets/icons/marker_red.png";
                        color = 'rgba(128, 136, 255, 0.70)';
                        stroke = 'rgba(128, 136, 255, 0.90)';
                        textColor = '#000';
                        break;
                    case 4:
                        src = "../assets/icons/marker_yellow.png";
                        color = 'rgba(255, 255, 0, 0.70)';
                        stroke = 'rgba(255, 255, 0, 0.90)';
                        textColor = '#000';
                        break;
                    case 5:
                        src = "../assets/icons/marker_pink.png";
                        color = 'rgba(255, 0, 255, 0.70)';
                        stroke = 'rgba(255, 0, 255, 0.90)';
                        textColor = '#000';
                        break;
                    case 6:
                        src = "../assets/icons/marker_orange.png";
                        color = 'rgba(104, 33, 255, 0.70)';
                        stroke = 'rgba(104, 33, 255, 0.90)';
                        textColor = '#000';
                        break;
                    case 7:
                        src = "../assets/icons/marker_cyan.png";
                        color = 'rgba(0, 255, 255, 0.70)';
                        stroke = 'rgba(0, 255, 255, 0.90)';
                        textColor = '#000';
                        break;
                    case 8:
                        src = "../assets/icons/marker_orange.png";
                        color = 'rgba(255, 128, 0, 0.70)';
                        stroke = 'rgba(255, 128, 0, 0.90)';
                        textColor = '#000';
                        break;
                    default:
                        color = 'rgba(51, 153, 204, 1.0)';
                        stroke = 'rgba(51, 153, 204, 1.0)';
                        textColor = '#FFF';
                        strokeWidth = 0;
                        break;
                }

                var amplitude = mapAmplitude(feature.get('features')[0].getProperties().amplitude, amplitudeMin, amplitudeMax, 7, 14)
                var count = feature.get('features')[0].getProperties().count;
                var iconStyle = [
                    new ol.style.Style({
                        image: new ol.style.Circle({
                            radius: amplitude,
                            fill: new ol.style.Fill({color: color}),
                            stroke: new ol.style.Stroke({
                                color: stroke,
                                width: strokeWidth
                            })
                        })
            
                    })
                ];
                styleCache[size] = iconStyle;
                if(map.getView().getZoom()<=10){
                    iconStyle[0].getImage().setScale(map.getView().getZoom()/20);
                }else if(map.getView().getZoom()>10 && map.getView().getZoom()<=14){
                    iconStyle[0].getImage().setScale(map.getView().getZoom()/18);
                }else if(map.getView().getZoom()>14 && map.getView().getZoom()<=16){
                    iconStyle[0].getImage().setScale(map.getView().getZoom()/17);
                }else if(map.getView().getZoom()>16 && map.getView().getZoom()<=18){
                    iconStyle[0].getImage().setScale(map.getView().getZoom()/16);
                }else if(map.getView().getZoom()>18 && map.getView().getZoom()<=20){
                    iconStyle[0].getImage().setScale(map.getView().getZoom()/14);
                }else{
                    iconStyle[0].getImage().setScale(map.getView().getZoom()/12);
                }
                return iconStyle;
            }else{
                var style = styleCache[size];
                if (!style) {
                    style = new ol.style.Style({
                        image: new ol.style.Circle({
                            radius: 30,
                            stroke: new ol.style.Stroke({
                                color: '#3399CC'
                            }),
                            fill: new ol.style.Fill({
                                color: '#3399CC'
                            })
                        }),
                        text: new ol.style.Text({
                            text: size.toString(),
                            fill: new ol.style.Fill({
                                color: '#fff'
                            })
                        })
                    });
                    styleCache[size] = style;
                }
                style.getImage().setScale(resolution / (resolution/map.getView().getZoom())/15);
                return style;
            }
        }
    });

    map.addLayer(clusters);

    map.on('click', function(event) {
        map.forEachFeatureAtPixel(event.pixel, function(feature,layer) {
            if ( feature.get('features')[0].getProperties().id == "detection" && feature.get('features').length == 1) {
                for(i=0;i<1;i++){
                    var clickFeature = feature.get('features')[0];
                    var geometry = clickFeature.getGeometry();
                    var coord = geometry.getCoordinates();

                    var color = 'rgba(0, 255, 255, 0.70)';
                    var stroke = 'rgba(0, 255, 255, 0.90)';
                    var textColor = '#000';

                    iconStyle = [
                        new ol.style.Style({
                            image: new ol.style.Circle({
                                radius: clickFeature.getProperties().amplitude,
                                fill: new ol.style.Fill({color: color}),
                                stroke: new ol.style.Stroke({
                                    color: stroke,
                                    width: 2.5
                                })
                            })
                
                        }),
                        new ol.style.Style({
                            text: new ol.style.Text({
                                text: clickFeature.getProperties().count+"",
                                fill: new ol.style.Fill({
                                    color: textColor
                                })
                            })
                        })
                    ];
                    
                    var popupText = '<p>Detected technology: '+clickFeature.getProperties().techName+'</p>'+
                        '<p>Longitude: '+clickFeature.getProperties().lon+ ', Latitude: '+clickFeature.getProperties().lat+'</p>' + 
                        '<p>Detected times: '+clickFeature.getProperties().count+'</p>' +
                        '<p>Latest amplitude: '+clickFeature.getProperties().amplitude+'</p>' + '<p>Last detected: '+clickFeature.getProperties().timestamp+'</p>';
                    
                    var hdms = ol.coordinate.toStringHDMS(ol.proj.toLonLat(coord));

                    content.innerHTML = popupText;
                    overlay.setPosition(coord);
                }
            } else {
                closePopup();
            }
        });
    });
}

function createMarker(detection, technologyid, technology, count, amplitudeMax, amplitudeMin){
    lat = detection.location.coordinates[1];
    lon = detection.location.coordinates[0];
    if(technologyid.length>1){
        for(j=0;j<technologyid.length;j++){
            if(j==0){
                techId = technologyid[j];
                techName = technology[j];
            }else{
                techId = techId + ", " + technologyid[j];
                techName = techName + ", " + technology[j];
            }
        }
    }else{
        techName = detection.technology;
        techId = detection.technologyid;
    }
    amplitude = detection.amplitude;
    timestamp = detection.timestamp;
    count = count;
    var marker = new ol.Feature({
        id: "detection",
        type: "click",
        geometry: new ol.geom.Point(
          ol.proj.fromLonLat([lon,lat])
        ),
        name: detection.technology + "-" + detection.timestamp,
        lat: lat,
        lon: lon,
        techName: techName,
        techId: techId,
        amplitude: amplitude,
        timestamp: timestamp,
        count: count,
    });

    marker.setId(detection.technology + "-" + detection.timestamp);
    marker.setProperties({'Technology': detection.technology, 'SpoofDecision': detection.spoofDecision, 'Amplitude': detection.amplitude, 'Timestamp': detection.timestamp});
    var color = 'rgba(0, 0, 255, 0.70)';
    var stroke = 'rgba(0, 0, 255, 0.90)';
    var textColor = '#FFF';

    var src = "../assets/icons/marker_black.png";
    var strokeWidth = 2.5;
    switch(techId){
        case 0:
            src = "../assets/icons/marker_black.png";
            color = 'rgba(0, 0, 0, 0.70)';
            stroke = 'rgba(0, 0, 0, 0.90)';
            textColor = '#FFF';
            break;
        case 1:
            src = "../assets/icons/marker_green.png";
            color = 'rgba(214, 188, 40, 0.70)';
            stroke = 'rgba(214, 188, 40, 0.90)';
            textColor = '#000';
            break;
        case 2:
            src = "../assets/icons/marker_blue.png";
            color = 'rgba(0, 0, 255, 0.70)';
            stroke = 'rgba(0, 0, 255, 0.90)';
            textColor = '#FFF';
            break;
        case 3:
            src = "../assets/icons/marker_red.png";
            color = 'rgba(128, 136, 255, 0.70)';
            stroke = 'rgba(128, 136, 255, 0.90)';
            textColor = '#000';
            break;
        case 4:
            src = "../assets/icons/marker_yellow.png";
            color = 'rgba(255, 255, 0, 0.70)';
            stroke = 'rgba(255, 255, 0, 0.90)';
            textColor = '#000';
            break;
        case 5:
            src = "../assets/icons/marker_pink.png";
            color = 'rgba(255, 0, 255, 0.70)';
            stroke = 'rgba(255, 0, 255, 0.90)';
            textColor = '#000';
            break;
        case 6:
            src = "../assets/icons/marker_orange.png";
            color = 'rgba(104, 33, 255, 0.70)';
            stroke = 'rgba(104, 33, 255, 0.90)';
            textColor = '#000';
            break;
        case 7:
            src = "../assets/icons/marker_cyan.png";
            color = 'rgba(0, 255, 255, 0.70)';
            stroke = 'rgba(0, 255, 255, 0.90)';
            textColor = '#000';
            break;
        case 8:
            src = "../assets/icons/marker_orange.png";
            color = 'rgba(255, 128, 0, 0.70)';
            stroke = 'rgba(255, 128, 0, 0.90)';
            textColor = '#000';
            break;
        default:
            color = 'rgba(51, 153, 204, 1.0)';
            stroke = 'rgba(51, 153, 204, 1.0)';
            textColor = '#FFF';
            strokeWidth = 0;
            break;
    }

    var amplitude = mapAmplitude(detection.amplitude, amplitudeMin, amplitudeMax, 7, 14)
    iconStyle = [
        new ol.style.Style({
            image: new ol.style.Circle({
                radius: amplitude,
                fill: new ol.style.Fill({color: color}),
                stroke: new ol.style.Stroke({
                    color: stroke,
                    width: strokeWidth
                })
            })

        }),
        new ol.style.Style({
            text: new ol.style.Text({
                text: count+"",
                fill: new ol.style.Fill({
                    color: textColor
                })
            })
        }),
    ];
    marker.setStyle(iconStyle);

    return marker;
}

function openNav() {
    closeFilter();
    closeLegend();
    document.getElementById("sidepanel").style.width = "250px";
    document.getElementById("openbtn").style.marginLeft = "270px";
    document.getElementById("openbtnOn").style.display = "none";
    document.getElementById("openbtnOff").style.display = "block";
    document.getElementById("infobtn").style.marginLeft = "330px";
  }
  
function closeNav() {
    document.getElementById("sidepanel").style.width = "0px";
    document.getElementById("openbtn").style.marginLeft = "50px";
    document.getElementById("openbtnOn").style.display = "block";
    document.getElementById("openbtnOff").style.display = "none";
    document.getElementById("infobtn").style.marginLeft = "110px";
}

function openFilter() {
    closeNav();
    closeLegend();
    document.getElementById("sidepanelFilter").style.width = "250px";
    document.getElementById("openbtnFilter").style.marginRight = "270px";
    document.getElementById("openbtnFilterOn").style.display = "none";
    document.getElementById("openbtnFilterOff").style.display = "block";
  }
  
function closeFilter() {
    document.getElementById("sidepanelFilter").style.width = "0px";
    document.getElementById("openbtnFilter").style.marginRight = "20px";
    document.getElementById("openbtnFilterOn").style.display = "block";
    document.getElementById("openbtnFilterOff").style.display = "none";
}

function openLegend() {
    closeNav();
    closeFilter();
    document.getElementById("sidepanelLegend").style.height = "250px";
    document.getElementById("sidepanelLegend").style.width = "250px";
    document.getElementById("openbtnLegendOn").style.display = "none";
    document.getElementById("openbtnLegendOff").style.display = "block";
    document.getElementById("openbtnLegend").style.marginBottom = "250px";
}

function closeLegend() {
    document.getElementById("sidepanelLegend").style.height = "0px";
    document.getElementById("sidepanelLegend").style.width = "0px";
    document.getElementById("openbtnLegendOn").style.display = "block";
    document.getElementById("openbtnLegendOff").style.display = "none";
    document.getElementById("openbtnLegend").style.marginBottom = "22.5px";
}

function openInfo() {
    document.getElementById("infoscreen").style.display = "block";
}

function closeInfo() {
    document.getElementById("infoscreen").style.display = "none";
}

function filterMap(){
    let location = document.getElementById("location").value;
    if (location === "") {
        location = undefined;
    }
    let selectedtechnologies = [];
    let technologies = document.getElementsByClassName("technology");
    let technologycounter = 0;
    let errorNoTech = document.getElementById("errornotechnologiesselected");
    for(i = 0; i<technologies.length;i++){
        if (technologies[i].checked) {
            selectedtechnologies[technologycounter] = technologies[i].id;
            technologycounter++;
        }
    }
    if(technologycounter == 0){
        errorNoTech.innerHTML = "Please select at least one technology for filtering!";
    }else{
        errorNoTech.innerHTML = "";
        let datefrom = document.getElementById("datefrom").value;
        let timefrom = document.getElementById("timefrom").value;
        let dateto = document.getElementById("dateto").value;
        let timeto = document.getElementById("timeto").value;
        let datetimefrom;
        let datetimeto;

        if (datefrom !== "" && timefrom !== ""){
            datetimefrom = datefrom + "T" + timefrom + ":00.000Z";
        } else if (datefrom !== "") {
            datetimefrom = datefrom + "T" + "00:00:00.000Z";
        } else {
            datetimefrom = undefined;
        }
        if (dateto !== "" && timeto !== ""){
            datetimeto = dateto + "T" + timeto + ":00.000Z";
        } else if (dateto !== "") {
            datetimeto = dateto + "T" + "23:59:59.000Z";
        } else {
            datetimeto = undefined;
        }


        let range = document.getElementById("range").value;
        
        const filterData = {location: encodeURIComponent(location), technology: selectedtechnologies, datetimefrom: datetimefrom, datetimeto: datetimeto, range: range};
        closePopup();
        socket.emit('sendFilterSpecs', filterData);
    }
}

function addTechnologiesToSidebar(technologies){
    let technologycontainer = document.getElementById("technologycontainer");
    for(i = 0; i<technologies.length;i++){
        let technologyp = document.createElement('div');
        let technologypspace = document.createElement('span');
        let input = document.createElement("INPUT");
        input.setAttribute("type", "checkbox");
        input.setAttribute("name", technologies[i].name);
        input.setAttribute("id", technologies[i].technologyid);
        input.setAttribute("class", "technology");
        input.checked = true;
        technologyp.appendChild(input);
        technologypspace.innerHTML = technologies[i].name;
        technologyp.appendChild(technologypspace);
        technologycontainer.appendChild(technologyp);
    }
}

function setDefaultOfFilter(){
    let dateto = document.getElementById("dateto");
    let timeto = document.getElementById("timeto");

    var today = new Date();
    var dd = String(today.getDate()).padStart(2, '0');
    var mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
    var yyyy = today.getFullYear();

    var date = yyyy + '-' + mm + '-' + dd;
    dateto.value = date;

    var hours = String(today.getHours());
    var minutes = String(today.getMinutes());

    var time = hours + ':' + minutes;
    timeto.value = time;

}

function mapAmplitude(value, from1, to1, from2, to2){
   return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
}