import { useForm } from "react-hook-form";
import Button from "../../ui/Button";
import Form from "../../ui/Form";
import FormRow from "../../ui/FormRow";
import Input from "../../ui/Input";

// Email regex: /\S+@\S+\.\S+/

function SignupForm() {
  const { register, formState ,getValues,reset ,handleSubmit} = useForm();
  
  const { errors } = formState;
 

  function onSubmit(data) {
    console.log(data);
  }

  return (
    <Form onSubmit={handleSubmit(onSubmit)}>
      <FormRow label="Full name">
        <Input type="text" id="fullName" {...register("fullname",{required:"this field is required"})} />
      </FormRow>

      <FormRow label="Email address" error={errors?.email?.message}>
        <Input type="text" id="email"
          {...register("email",
            {
              required:
                "this field is required",
              pattern:
              {
                value: /\S+@\S+\.\S+/,
                message:
                  "Please provide a valid email adress"
              }
            })} />
      
      </FormRow>

      <FormRow label="Password (min 8 characters)" error={errors?.password?.message}>
        <Input type="password" id="password" {...register("password",{required:"this field is required",minLength:{value:8,message:"Password needs a minimum of 8 char"}})}/>
      </FormRow>

      <FormRow label="Repeat password" error={errors?.passwordConfirm?.message}>
        <Input type="password" id="passwordConfirm" {...register("passwordConfirm",
          {
            required:
              "this field is required", validate: (value) => value === getValues().password||"Passwords needs to mach"
          })} />
      </FormRow>

      <FormRow>
        {/* type is an HTML attribute! */}
        <Button variation="secondary" onClick={reset} type="reset">
          Cancel
        </Button>
        <Button>Create new user</Button>
      </FormRow>
    </Form>
  );
}

export default SignupForm;
