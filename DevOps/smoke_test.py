import sys
import requests
import requests.exceptions

def main():
    URL = 'http://localhost:44340/users/1'
    TIMEOUT = 10

    try:
        response = requests.get(URL, timeout = TIMEOUT)
        print("Request sent")
    except:
        print("Request not sent")
        sys.exit(-1)

    try:
        response.raise_for_status()
        print("Successful")
    except HttpError:
        print("Error")
        sys.exit(-1)

if __name__ == "__main__":
    main()