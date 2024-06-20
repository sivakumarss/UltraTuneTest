/* eslint-disable @typescript-eslint/no-unused-vars */
import './App.css';
import FullCalendar from '@fullcalendar/react';
import dayGridPlugin from '@fullcalendar/daygrid';
import interactionPlugin from "@fullcalendar/interaction"; 
import { useState } from 'react';
import SearchComponent from './search';
import { Tooltip } from "bootstrap";

let tooltipInstance: Tooltip | null = null;
function Calender() {

    const fullCalender = "https://fullcalendar.io/docs/react";
    const eventBookings = [
        {
            title: 'Submission', extendedProps: { description: 'Siva submitting React Test' }, overlap: true, date: '2024-06-21' },
        { title: 'Offer', extendedProps: { description: 'Siva received offer' }, overlap: true, date: '2024-06-24' },
        { title: 'Joined', extendedProps: { description: 'Siva Joined UltraTune' }, overlap: true, date: '2024-06-27' }
    ]

    const [search, setSearch] = useState("")


    const handleDateClick = (info: { dateStr: unknown; }) => {
        alert(info.dateStr)
    }

    const handleMouseEnter = (info) => {
        if (info.event.extendedProps.description) {
            tooltipInstance = new Tooltip(info.el, {
                title: info.event.extendedProps.description,
                html: false,
                placement: "bottom",
                trigger: "hover",
                container: "body"
            });

            tooltipInstance.show();
        }
    };

    const handleMouseLeave = () => {
        if (tooltipInstance) {
            tooltipInstance.dispose();
            tooltipInstance = null;
        }
    };

    const handleEventClick = (clickInfo) => {
        if (confirm(`Are you sure you want to delete the event '${clickInfo.event.title}'`)) {
            clickInfo.event.remove()
        }
    }


    return (
        <div>
            <h1 id="tabelLabel">Calender component</h1>
            <p>Calender component uses this plugin:   FullCalendar: <a target="_blank" href={fullCalender}>{fullCalender}</a>.</p>

            <SearchComponent />
            {/*<ReactTooltip id="registerTip" place="top" effect="solid" >*/}
                <FullCalendar
                    plugins={[dayGridPlugin, interactionPlugin]}
                    initialView="dayGridMonth"
                    weekends={false}
                    eventMouseEnter={handleMouseEnter}
                    eventMouseLeave={handleMouseLeave}
                    dateClick={handleDateClick}
                    eventContent={renderEventContent}
                    events={eventBookings}
                    eventClick={handleEventClick}
                    />
            {/*<ReactTooltip />*/}

        </div>
    );


}



function renderEventContent(eventInfo) {
    return (
        <>
            <b>{eventInfo.timeText}</b>
            <i>{eventInfo.event.title}</i>
        </>
    )
}

export default Calender;