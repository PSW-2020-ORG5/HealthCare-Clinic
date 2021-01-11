import sys
import requests
import requests.exceptions

def main():
    URL = 'localhost:44395'
    TIMEOUT = 10

    try:
        response = requests.get(URL, timeout = TIMEOUT)
    except:
        sys.exit(-1)

    try:
        response.raise_for_status()
    except HttpError:
        sys.exit(-1)

if __name__ == "__main__":
    main()