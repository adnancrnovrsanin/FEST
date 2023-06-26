import { useField } from "formik";

interface Props {
    placeholder: string;
    name: string;
    label?: string;
    type?: string;
}

const CustomTextInput = (props: Props) => {
    const [field, meta] = useField(props.name);

    return (
        <div className="textField">
            <label htmlFor={props.name}>{props.label}</label>
            <input
                {...field}
                {...props}
                className={`form-control shadow-none ${meta.touched && meta.error && "is-invalid"}`}
                placeholder={props.placeholder}
                autoComplete="off"
            />
            {meta.touched && meta.error ? (
                <div className="invalid-feedback">{meta.error}</div>
            ) : null}
        </div>
    );
};

export default CustomTextInput;