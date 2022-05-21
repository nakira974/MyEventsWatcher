function displayVenues(map, venues) {
    venues.forEach(venue => {
        var myLatLng = { lat: -25.363, lng: 131.044 };
        new google.maps.Marker({
            position: myLatLng,
            map,
            title: "Hello World!",
        });

    });
}