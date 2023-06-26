import { observer } from "mobx-react-lite";
import './style.css';
import { Formik, Form } from "formik";
import CustomTextInput from "../../common/form/CustomTextInput/CustomTextInput";
import { DatePicker, LocalizationProvider } from "@mui/x-date-pickers";
import { AdapterMoment } from '@mui/x-date-pickers/AdapterMoment'
import moment from "moment";

const AdminCreateFestival = () => {
    return (
        <div className="festivalCreateContainer">
            <h1>Create a new festival</h1>

            <LocalizationProvider dateAdapter={AdapterMoment}>
                <Formik
                    initialValues={{
                        name: "",
                        startDate: new Date(),
                        endDate: new Date(),
                        city: "",
                        zipCode: "",
                        organizer: 0
                    }}
                    onSubmit={values => {
                        console.log(values);
                    }}
                >
                    {({ handleSubmit, values, setFieldValue }) => (
                        <Form className="createFestivalForm">
                            <CustomTextInput label="Name" name="name" placeholder="Enter name" />
                            <DatePicker 
                                label="Start date"
                                value={moment(values.startDate)}
                                onChange={(newValue) => {
                                    setFieldValue("startDate", newValue?.toDate());
                                }}
                            />
                            <DatePicker 
                                label="End date"
                                value={moment(values.endDate)}
                                onChange={(newValue) => {
                                    setFieldValue("endDate", newValue?.toDate());
                                }}
                            />
                            <CustomTextInput label="City" name="city" placeholder="Enter city" />
                            <CustomTextInput label="Zip code" name="zipCode" placeholder="Enter zip code" />

                            <button className="btn btn-outline-dark" type="submit">Create</button>
                        </Form>
                    )}
                </Formik>
            </LocalizationProvider>
        </div>
    )
}

export default observer(AdminCreateFestival);