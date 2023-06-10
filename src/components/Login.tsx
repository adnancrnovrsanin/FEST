import { Formik, Form } from 'formik';
import { TextField } from './TextField';
import * as Yup from 'yup';


export const Login = () => {
  const validate = Yup.object({
    email: Yup.string()
      .email('Email is invalid')
      .required('Email is required'),
    password: Yup.string()
      .min(6, 'Password must be at least 6 charaters')
      .required('Password is required'),
  })
  return (
    <Formik
      initialValues={{
        email: '',
        password: '',
      }}
      validationSchema={validate}
      onSubmit={values => {
        console.log(values)
      }}
    >
      {formik => (
        <div>
          <h1 className="my-4 font-weight-bold .display-4">Login</h1>
          <Form>
            <TextField label="Email" name="email" type="email" />
            <TextField label="Password" name="password" type="password"  />
            <button className="btn btn-dark mt-3" type="submit">Login</button>
            <button className="btn btn-danger mt-3 ml-3" type="reset">Reset</button>

          </Form>
        </div>
      )}
    </Formik>
  )
}
